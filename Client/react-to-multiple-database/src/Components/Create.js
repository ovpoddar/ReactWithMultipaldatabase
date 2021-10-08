import React, {useState} from 'react';
export default function Create() {
const [firstName, setFirstName] = useState("");
const [lastName, setLastName] = useState("");
const [email, setEmail] = useState("");
const [mobileNo, setMobileNo] = useState("");
const [address, setAddress] = useState("");
const [pinCode, setPinCode] = useState("");
    const handleSubmit = (event) => {
        event.preventDefault();
        var model = JSON.stringify({
            FirstName: firstName,
            LastName: lastName,
            EmailId: email,
            MobileNumber: mobileNo,
            Address: address,
            Pincode: pinCode 
        });
        var http = new XMLHttpRequest();
        http.onreadystatechange = function () {
            var result = this.responseText;
            if (http.readyState === 4) {
                if (http.status === 201) {
                    result = JSON.parse(this.responseText);
                    window.location.href ="/";
                } else {
                    console.log(result);
                }
            }
        };
        http.open("POST", "https://localhost:44313/api/FormData", true);
        http.setRequestHeader('Content-type', 'application/json');
        http.send(model);
    }

    return (
        <div>
            <h2>Create</h2>
            <div className="row">
                <div className="col sm-7">
                    <form method="post" onSubmit={handleSubmit}>
                        <div className="form-group">
                            <label htmlFor="firstName">First Name</label>
                            <input type="text" className="form-control" id="firstName" value={firstName} onChange={(e) => {setFirstName(e.target.value)}} placeholder="First Name" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="lastName">Last Name</label>
                            <input type="text" className="form-control" id="lastName" value={lastName} onChange={(e) => {setLastName(e.target.value)}} placeholder="Last Name" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="email">Email address</label>
                            <input type="email" className="form-control" id="email" value={email} onChange={(e) => setEmail(e.target.value)} placeholder="Email Id" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="mobileNo">Mobile No</label>
                            <input type="text" accept="number" className="form-control" id="mobileNo" value={mobileNo} onChange={(e) => {setMobileNo(e.target.value)}} placeholder="Mobile No" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="Address">Address</label>
                            <input type="text" className="form-control" id="Address" value={address} onChange={(e) => setAddress(e.target.value)} placeholder="Address" />
                        </div>
                        <div className="form-group">
                            <label htmlFor="pinCode">PinCode</label>
                            <input type="text" accept="number" className="form-control" id="pinCode" value={pinCode} onChange={(e) =>setPinCode(e.target.value)} placeholder="PinCode" />
                        </div>
                        <div className="form-group">
                            <button type="submit" className="btn btn-success">Submit</button>
                        </div>
                    </form>
                </div>
            </div>
        </div>
    )
}
