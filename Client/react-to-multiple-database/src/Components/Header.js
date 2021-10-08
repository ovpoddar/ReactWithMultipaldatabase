import React from 'react';
import { Link } from 'react-router-dom';

export default function Header() {
    return (
        <header>
            <nav className="navbar-expand-sm navbar-toggleable-sm ng-white border-bottom box-shadow mb-3 navbar navbar-light">
                <div className="container">
                    <Link className="navbar-brand" to="/">Project1</Link>
                    <button aria-label="Toggle navigation" type="button" className="mr-2 navbar-toggler">
                        <span className="navbar-toggler-icon"></span>
                    </button>
                    <div className="d-sm-inline-flex flex-sm-row-reverse collapse navbar-collapse">
                        <ul className="navbar-nav flex-grow">
                            <li className="nav-item"><Link className="text-dark nav-link" to="/">Home</Link></li>
                            <li className="nav-item"><Link className="text-dark nav-link"  to="/Add">Create</Link></li>
                        </ul>
                    </div>
                </div>
            </nav>
        </header>
    )
}
