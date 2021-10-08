import React, { Component } from 'react'
import  Header  from "./Header";

export class Layout extends Component {
    render() {
        return (
            <div>
                <Header></Header>
                <div className="Container">
                    {this.props.children}
                </div>
            </div>
        )
    }
}
