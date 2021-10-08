import React, { Component } from 'react'

export default class Home extends Component {
    constructor(props) {
        super(props);
        this.state = { models: [], error: null, loading: true };
    }

    render() {
        var contents = this.state.loading
            ? <p><em>Loading...</em></p>
            : <table>
                <thead className="btn-primary">
                    <tr>
                        <th>First Name</th>
                        <th>Last Name</th>
                        <th>EmailId</th>
                        <th>MobileNo</th>
                        <th>Address</th>
                        <th>PinCode</th>
                        <th>Action</th>
                    </tr>
                </thead>
                <tbody>
                    {this.state.models.map(model => (
                        <tr key={model.id}>
                            <td>{model.firstName}</td>
                            <td>{model.lastName}</td>
                            <td>{model.emailId}</td>
                            <td>{model.mobileNo}</td>
                            <td>{model.address}</td>
                            <td>{model.pinCode}</td>
                            <td><button variant="info" onClick={() => this.editUser(model.id)}>Edit</button>
                                <button variant="danger" onClick={() => this.deleteUser(model.id)}>Delete</button>

                            </td>
                        </tr>
                    ))}
                </tbody>
            </table>;

        return (
            <div>
                <h1>List of Users</h1>
                
                {contents}
            </div>
        )
    }

    editUser(userId) {
        console.log(userId + "of Edited");
    };

    deleteUser(userId) {
        var currentComponent = this;
        
        const { models } = this.state;  
        var http = new XMLHttpRequest();
        http.onreadystatechange = function () {
            var result = this.responseText;
            if (http.readyState === 4) {
                if (http.status === 200) {
                    currentComponent.setState({
                        models: models.filter(user=>user.id !== userId)
                    })
                } else {
                    alert(result);
                }
            }
        };
        http.open("DELETE", "https://localhost:44313/api/FormData/" + userId, true);
        http.send();
    };
    
    componentDidMount(){
        var currentComponent = this;
        var http = new XMLHttpRequest();
        http.onreadystatechange = function () {
            var result = this.responseText;
            if (http.readyState === 4) {
                currentComponent.setState({ loading: false });
                if (http.status === 200) {
                    result = JSON.parse(this.responseText);
                    currentComponent.setState({ models: result });
                } else {
                    currentComponent.setState({ error: result });
                }
            }
        };
        http.open("GET", "https://localhost:44313/api/FormData", true);
        http.send();
    }
}
