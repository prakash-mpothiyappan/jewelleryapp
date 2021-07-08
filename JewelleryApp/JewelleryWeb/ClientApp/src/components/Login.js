import React, { useState } from 'react';
import { Table,TableRow,TableCell,Button,TextField } from '@material-ui/core';
import { authenticationService } from '../_services/authenticationService';



export default function Login(props) {

    const [values, SetValues] = useState({
        username: "", password: ""
    });
    
    const login = () => {

        if (values.username === "" || values.password == "") {
            alert("Please enter UserName/Password ");
            return;
        }

        authenticationService.login(values.username, values.password).then(
            user => {
                 props.history.push("/");
            }, error => {
              alert("You're not authorized");
            }
        );
    }

    const handleChange = (event) => {
        SetValues({
            ...values, [event.target.name]: event.target.value
        });
  }
  
  const Clear = () => {
    SetValues({
      username: "", password: ""
    })
  }

    return (
      <div className="RadiusCorner">

        <Table >
          <TableRow>
            <TableCell>
              <label>User Name</label>
            </TableCell>
                    <TableCell>
                        <TextField value={values.username} onChange={handleChange} name="username" label="User Name" variant="outlined" />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell>
              <label>Password</label>
            </TableCell>
                    <TableCell>
                        <TextField type="password" value={values.password} onChange={handleChange} name="password" label="Password" variant="outlined" />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell>
            </TableCell>
                    <TableCell>
                        <Button type="submit" onClick={login } id="btnlogin" variant="contained" color="primary">Login</Button>
              <span style={{margin:"10px"}}></span>
              <Button variant="contained" onClick={Clear} color="primary">Cancel</Button>
            </TableCell>
          </TableRow>
        </Table>
      
    </div>
    );
  
}
