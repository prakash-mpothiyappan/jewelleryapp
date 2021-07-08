import React, { useState } from 'react';
import { Table,TableRow,TableCell,Button,Dialog,DialogTitle,TextField } from '@material-ui/core';
import { PDFDownloadLink } from '@react-pdf/renderer';
import { MyDocument } from './PDFViewer.js';
import { useHistory } from 'react-router-dom';
import { authenticationService } from '../_services/authenticationService.js';
import Discount from './Discount.js';

export default function StoreDetails() {
  const [values, SetValues] = useState({
    goldPrice:0, weight:0, discount:2
  });

  const [totalPrice, SetTotalPrice] = useState(0);
  const [Open, SetOpen] = useState(false);
  const isAuthrozid = authenticationService.currentUserValue.IsAuthrozied
  
  const history = useHistory();

  const routeChange = () =>{ 
    let path = `/`; 
    history.push(path);
  }
  
    const Calculate = () => {
        validation();
    let total = (values.goldPrice * values.weight);
    total = total - ((values.discount / 100) * total);
    SetTotalPrice(total);
  }

  const ShowMessage = () => {
      if (totalPrice === 0) {
          alert("Please do calculation")
          return;
      }
    SetOpen(true)
  }

  const handleChange = (event) => {
    
    SetValues({
      ...values, [event.target.name]: event.target.value
    });
    }

    function validation() {
        if (values.goldPrice === 0 || values.discount === 0 || values.weight === 0) {
            alert("Please Enter Values")
            return;
        }
    }
  
  const handleClose = () => {
    SetOpen(false)
  };

 const logout=()=> {
    authenticationService.logout();
    history.push('/login');
    }

    const printPaper = () => {
        alert("Not Implemented")
    }
 
  return (
    <div className="RadiusCorner">
      <Dialog onClose={handleClose} aria-labelledby="simple-dialog-title" open={Open}>
        <DialogTitle id="OutuputDialog" >
            <Table>
              <TableRow>
                <label>Gold Price(gm) :</label>
                <label>{ values.goldPrice}</label>
              </TableRow>
              <TableRow>
                <label>Weight(gm) :</label>
                <label>{ values.weight}</label>
            </TableRow>
            {
              isAuthrozid &&
              <TableRow>
                <label>Discount(%) :</label>
                <label>{ values.discount}</label>
              </TableRow>
            }
              <TableRow>
                <label>Total Price :</label>
                <label>{ totalPrice}</label>
                </TableRow>
            </Table> 
            <Button variant="outlined" onClick={handleClose}>Ok</Button>
        </DialogTitle>
      </Dialog>

      <div>
    
  </div>
      
      <Table >
        <TableRow style={{ float: "right" }}>
          <TableCell>
          <div>Welcome: {authenticationService.currentUserValue.Role} User</div>
          </TableCell>
          <TableCell>
          <a onClick={logout} className="nav-item nav-link">Logout</a>
          </TableCell>
        </TableRow>
          <TableRow>
            <TableCell>
              <label>Gold Price (per gram)</label>
            </TableCell>
            <TableCell>
            <TextField name="goldPrice" type="number" onChange={handleChange} variant="outlined" />
            </TableCell>
          </TableRow>
          <TableRow>
            <TableCell>
              <label>Weight (grams)</label>
            </TableCell>
            <TableCell>
              <TextField name="weight" type="number" onChange={handleChange} variant="outlined" />
            </TableCell>
        </TableRow>
        <TableRow>
          <TableCell>
            <label>Total Price</label>
          </TableCell>
          <TableCell>
          <TextField  value={totalPrice} variant="filled" />
          </TableCell>
        </TableRow>
        <Discount click={handleChange} ></Discount>
          <TableRow>
             <TableCell>
              <Button variant="contained" onClick={Calculate} color="primary">Calculate</Button>
              <span style={{margin:"10px"}}></span>
              <Button variant="contained" onClick={ShowMessage} color="primary">Print to Screen</Button>
              <span style={{ margin: "10px" }}></span>
              <PDFDownloadLink document={<MyDocument totalPrice={totalPrice} IsAuthrozied={isAuthrozid} Values={values}></MyDocument>} fileName="Jewellery.pdf">
                <Button variant="contained" color="primary">Print to file</Button>
              </PDFDownloadLink>
                      <span style={{ margin: "10px" }}></span>
                      <Button variant="contained" onClick={ printPaper} color="primary">Print to Paper</Button>
              <span style={{ margin: "10px" }}></span>
              <Button variant="contained" onClick={routeChange} color="secondary">Cancel</Button>
            </TableCell>
          </TableRow>
        </Table>
    </div>
  )
  }

