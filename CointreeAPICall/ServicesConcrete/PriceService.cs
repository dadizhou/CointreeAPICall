using CointreeAPICall.Models;
using CointreeAPICall.ServicesAbstract;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;

namespace CointreeAPICall.ServicesConcrete
{
    public class PriceService : IPriceService
    {
        private readonly IDataService dataService;
        private readonly IPriceHistoryService priceHistory;
        private readonly IUserPreferenceService prefManager;

        public PriceService(IDataService dataService, IPriceHistoryService priceHistory, IUserPreferenceService prefManager)
        {
            this.dataService = dataService;
            this.priceHistory = priceHistory;
            this.prefManager = prefManager;
        }

        /// <summary>
        /// Get Price details on a coin
        /// </summary>
        /// <returns></returns>
        public async Task<PriceEnquiryResponse> GetCoinPriceDetails()
        {
            try
            {
                // 1. get user preference
                var coinSymbol = prefManager.GetUserPreferredCoin();
                // 2. call API to get current price
                var result = await CallPriceAPI(coinSymbol);
                // 3. get previous price percentage
                result.PriceChange = CalculatePriceDifference(result, priceHistory.GetPreviousPrice(coinSymbol));
                // 4. add price history
                priceHistory.UpdateCustomerPrice(coinSymbol, new CustomerPrice()
                {
                    Ask = result.Ask,
                    Bid = result.Bid,
                    Rate = result.Rate
                });

                return result;
            }
            catch (Exception e)
            {
                return CreateResponse(e.Message);
            }
        }

        /// <summary>
        /// Call Price API to get most recent price details
        /// </summary>
        /// <param name="coinSymbol"></param>
        /// <returns></returns>
        private async Task<PriceEnquiryResponse> CallPriceAPI(string coinSymbol)
        {
            var coinPriceDetail = new CoinPriceDetail();

            using (var httpClient = new HttpClient())
            {
                using (var response = await httpClient.GetAsync(dataService.CointreePriceURL() + coinSymbol))
                {
                    string apiResponse = await response.Content.ReadAsStringAsync();
                    coinPriceDetail = JsonConvert.DeserializeObject<CoinPriceDetail>(apiResponse);
                }
            }
            return CreateResponse(coinPriceDetail);
        }

        /// <summary>
        /// Create a normal response based on the API call
        /// </summary>
        /// <param name="coinPriceDetail"></param>
        /// <returns></returns>
        private PriceEnquiryResponse CreateResponse(CoinPriceDetail coinPriceDetail)
        {
            var result = new PriceEnquiryResponse()
            {
                Ask = coinPriceDetail.Ask,
                Bid = coinPriceDetail.Bid,
                Rate = coinPriceDetail.Rate
            };
            return result;
        }

        /// <summary>
        /// Response with error message
        /// </summary>
        /// <param name="errorMessage"></param>
        /// <returns></returns>
        private PriceEnquiryResponse CreateResponse(string errorMessage)
        {
            var result = new PriceEnquiryResponse();
            result.Messages.Add(errorMessage);
            return result;
        }

        /// <summary>
        /// Calculate price percentage changed from previous price enquiry
        /// </summary>
        /// <param name="customerPrice"></param>
        /// <returns></returns>
        private PricePercentage CalculatePriceDifference(PriceEnquiryResponse enquiryResponse, CustomerPrice previousPrice)
        {
            var result = new PricePercentage();

            if (previousPrice.Ask != 0)
                result.Ask = CalculatePercentage(previousPrice.Ask, enquiryResponse.Ask);
            if (previousPrice.Bid != 0)
                result.Bid = CalculatePercentage(previousPrice.Bid, enquiryResponse.Bid);
            if (previousPrice.Rate != 0)
                result.Rate = CalculatePercentage(previousPrice.Rate, enquiryResponse.Rate);

            return result;
        }

        /// <summary>
        /// Helper method to calculate percentage changed
        /// </summary>
        /// <param name="previousPrice"></param>
        /// <param name="currentPrice"></param>
        /// <returns></returns>
        private decimal CalculatePercentage(decimal previousPrice, decimal currentPrice)
        {
            return 100 * (currentPrice - previousPrice) / previousPrice;
        }
    }
}
