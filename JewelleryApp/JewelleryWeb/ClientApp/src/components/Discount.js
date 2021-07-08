import React from 'react';
import { TableRow,TableCell,TextField } from '@material-ui/core';
import { authenticationService } from '../_services/authenticationService.js';

export default function Discount( props) {
    const isAuthrozid = authenticationService.currentUserValue.IsAuthrozied

    if (isAuthrozid) {
        return (
        
            <TableRow >
              <TableCell>
                <label>Discount Percentage</label>
              </TableCell>
              <TableCell>
              <TextField name="discount" onChange={props.click} type="number"  variant="outlined" />
              </TableCell>
            </TableRow>
        )
    }
    else {
        return(<div></div>)
    }   
}

