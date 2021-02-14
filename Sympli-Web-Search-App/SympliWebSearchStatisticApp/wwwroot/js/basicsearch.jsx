
class SearchReportBox extends React.Component {

	constructor(props) {
		super(props);
		this.state = { result: null };
		this.handleSearch = this.handleSearch.bind(this);
	}

	loadSearchFromServer() {
		const xhr = new XMLHttpRequest();
		xhr.open('get', "/search?search=e-settlement&rank=www.sympli.com&searchengine=google", true);
		xhr.onload = (() => {
			if (xhr.status != 200) {
				alert(xhr.responseText);
				return;
			}
			const data = xhr.responseText;
			this.setState({
				result: {
					data: data,
					searchKeyword: "e-settlement",
					rankKeyword: "www.sympli.com"
				}
			});
		});

		xhr.onerror = (() => {
			const data = xhr.responseText;
		});

		xhr.send();
	}

	handleSearch(searchKeywords) {
		const queryString = "/search?search="
			+ searchKeywords.searchKeyword + "&rank="
			+ searchKeywords.rankKeyword + "&searchengine=google";
		const xhr = new XMLHttpRequest();
		xhr.open('get', queryString, true);

		xhr.onload = (() => {
			if (xhr.status != 200) {
				alert(xhr.responseText);
				return;
			}
			const data = xhr.responseText;
			this.setState({
				result: {
					data: data,
					searchKeyword: searchKeywords.searchKeyword ,
					rankKeyword: searchKeywords.rankKeyword
				}
			});


		});

		xhr.onerror = (() => {
			const data = xhr.responseText;
		});

		xhr.send();
	}
	
	componentDidMount() {
		this.loadSearchFromServer();
	}

	render() {
		return (
			<div className="searchReportBox">
				<h1><img src="https://www.sympli.com.au/wp-content/uploads/sympli-logo-black.svg" width="200" height="100"></img> Rank Search Statistics</h1>
				<SearchForm onSearch={this.handleSearch} data={this.state.result}></SearchForm>
			</div>
		);
	}
}

class SearchForm extends React.Component {
	constructor(props) {
		super(props);
		this.state = {
			data: null
		};

		this.handleSearchSubmit = this.handleSearchSubmit.bind(this);
	}

	handleSearchSubmit(keyWords) {
		this.props.onSearch(keyWords);
	}
	
	render() {
		const value = this.props != null ? this.props.data : this.state.data;
		return (
			<div className="searchForm">
				<div className="container">
					<div className="row">
						<div className="col-md-12">
							<SearchEntry onSearchSubmit={this.handleSearchSubmit}></SearchEntry>
						</div>
					</div>
					<div className="row">
						<div className="col-md-12">
							<SearchStatisticResult data={value}></SearchStatisticResult>
						</div>
					</div>
				</div>
			</div>
		);
	}
}

class SearchEntry extends React.Component {

	constructor(props) {
		super(props);

		this.handleSubmit = this.handleSubmit.bind(this);
		this.handleSearchKeyword = this.handleSearchKeyword.bind(this);
		this.handleRankKeyword = this.handleRankKeyword.bind(this);
		this.state = {
			searchKeyword: "e-settlement",
			rankKeyword: "www.sympli.com"
		};
	}

	handleSubmit(e) {
		e.preventDefault();
		if (this.state.searchKeyword === "" || this.state.rankKeyword === "")
			alert("Search or rank keywords cannot be empty.");
		else
			this.props.onSearchSubmit({ searchKeyword: this.state.searchKeyword, rankKeyword: this.state.rankKeyword })
	}
	handleSearchKeyword(e) {
		this.setState({ searchKeyword: e.target.value })
	}

	handleRankKeyword(e) {
		this.setState({rankKeyword : e.target.value})
	}
	render() {
		return (
			<form className="searchEntry" onSubmit={this.handleSubmit}>
				<div className="container">
					<div className="row">
						<div className="col-md-3">
							<div className="col-md-6">
								<label>Search Keyword:</label>
							</div>
							<div className="col-md-3">
								<input type="text" placeholder="Keyword Search" value={this.state.searchKeyword} onChange={this.handleSearchKeyword} />
							</div>
						</div>
						<div className="col-md-3">
							<div className="col-md-6">
								<label>Rank Keyword:</label>
							</div>
							<div className="col-md-3">
								<input type="text" placeholder="Rank Search" value={this.state.rankKeyword} onChange={this.handleRankKeyword} />
							</div>
						</div>
						<div className="col-md-1" >
							<input type="submit" value="Search" />
						</div>
					</div>
				</div>
			</form>
		);
	}
}

class SearchStatisticResult extends React.Component{

	constructor(props) {
		super(props);
	}

	render() {
		const value = this.props.data == null ? null : this.props.data ;
		return (
			<div className="searchStatisticResult">
				<div className="container">
					<div className="row">
						<div className="col-md-3">
							<label>Results:</label>
						</div>
					</div> 
					<div className="row">
						<div className="col-md-12">
							Following is the rank result from Google Search engine for the given search keyword: <strong>{ value != null ? value.searchKeyword : null} </strong>
							and rank Search: <strong>{value != null ? value.rankKeyword : null}</strong>
						</div>
					</div>
					<div className="row">
						<div className=" col-9 col-md-9">
							{value!=null?value.data:null}
						</div>
					</div> 
				</div>
			</div>
		);
	}
}


ReactDOM.render(<SearchReportBox url="/search"/>, document.getElementById('content'));