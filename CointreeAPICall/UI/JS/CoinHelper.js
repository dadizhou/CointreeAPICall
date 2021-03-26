function GetDefaultCoin(coinList) {
    if (coinList && coinList.length) {
        return coinList.find(c => c.isDefault === true).coinSymbol;
    }
    return "";
}

function updatePreferredCoinSymbol(coinSymbol) {
    this.setState({ coinSymbol });
}

function prepareDefaultCoin(selectedCoinSymbol) {
    this.setState({ selectedCoinSymbol });
}

class CurrentPreferredCoin extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            coinSymbol: ""
        };

        updatePreferredCoinSymbol = updatePreferredCoinSymbol.bind(this);
    }

    render() {
        return (
            <div>
                <label>Current preferred coin: </label>
                <label>{this.state.coinSymbol}</label>
            </div>
        );
    }
}

class CoinDropDown extends React.Component {
    constructor(props) {
        super(props);
        this.state = {
            dropdownOption: ""
        };
    }

    handleChange = (e) => {
        this.setState(state => ({
            dropdownOption: event.target.value
        }));
        prepareDefaultCoin(event.target.value);
    }

    render() {
        const coinList = this.props.coinListFromParent;
        const coinOptions = (coinList && coinList.length) ? coinList.map((coin) =>
            <option key={coin.coinSymbol}>{coin.coinSymbol}</option>
        ) : null;
        const selectedValue = (this.state.dropdownOption == "") ? this.props.defaultCoin : this.state.dropdownOption;
        return (
            <div>
                <label>Select a preferred coin</label>
                <select
                    id="coinList"
                    value={selectedValue}
                    onChange={this.handleChange}>
                    {coinOptions}
                </select>
            </div>
        );
    }
}

class SetDefaultCoinButton extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            selectedCoinSymbol: ""
        };

        prepareDefaultCoin = prepareDefaultCoin.bind(this);
    }

    SendDefaultCoin = (e) => {
        const requestOptions = {
            method: "POST",
            headers: {
                "Content-Type": "application/json",
                "Accept": "application/json"
            },
            body: JSON.stringify({ "PreferredCoin": this.state.selectedCoinSymbol })
        };
        fetch("https://localhost:5001/api/CointreeAPICall/SetUserPreferences", requestOptions)
            .then(response => response.json())
            .then(data => updatePreferredCoinSymbol(data));
    };

    render() {
        return (
            <button onClick={this.SendDefaultCoin}>Set Default Coin</button>
        );
    }
}

class SetDefaultCoin extends React.Component {
    constructor(props) {
        super(props);

        this.state = {
            coinList: null
        };
    }

    componentDidMount() {
        fetch("https://localhost:5001/api/CointreeAPICall/GetAllCoins",
            {
                mode: "cors",
                headers: { "Access-Control-Allow-Origin": "*" }
            })
            .then(response => response.json())
            .then(data => {
                this.setState({ coinList: data });
                updatePreferredCoinSymbol(GetDefaultCoin(data));
            });
    }

    render() {
        return (
            <div>
                <CurrentPreferredCoin />
                <CoinDropDown coinListFromParent={this.state.coinList} defaultCoin={GetDefaultCoin(this.state.coinList)} />
                <SetDefaultCoinButton />
            </div>
        );
    }
}

ReactDOM.render(
    <SetDefaultCoin />,
    document.getElementById("application-test-controls")
);