import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { useState } from 'react';
import DiseaseAdditionForm from './DiseaseAdditionForm';
function createData(fullname, id, fullAddress, phone, cellphone, bornDate) {
  return { fullname, id, fullAddress, phone, cellphone, bornDate };
}

const rows = [
  createData('Reut Shimborski', 258147369, 'finkel 11 PT', '0533193587', '039038976', '2020-01-02'),
  createData('Reut Shimborski', 258147368, 'finkel 11 PT', '0533193587', '039038976', '2020-01-02'),
  createData('Reut Shimborski', 258147369, 'finkel 11 PT', '0533193587', '039038976', '2020-01-02'),
  createData('Reut Shimborski', 258147369, 'finkel 11 PT', '0533193587', '039038976', '2020-01-02'),
];

export default function EmployeeLists() {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };
  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Name </TableCell>
            <TableCell align="right">Id</TableCell>
            <TableCell align="right">address</TableCell>
            <TableCell align="right">Phone</TableCell>
            <TableCell align="right">Cellphone</TableCell>
            <TableCell align="right">born Date</TableCell>
            <TableCell align='right'>disease details</TableCell>
            <TableCell align='right'>vaccine details</TableCell>

          </TableRow>
        </TableHead>
        <TableBody>
          {rows.map((row) => (
            <TableRow
              key={row.name}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">
                {row.fullname}
              </TableCell>
              <TableCell align="right">{row.id}</TableCell>
              <TableCell align="right">{row.fullAddress}</TableCell>
              <TableCell align="right">{row.phone}</TableCell>
              <TableCell align="right">{row.cellphone}</TableCell>
              <TableCell align="right">{row.bornDate}</TableCell>
              <TableCell align='right'>    <Button variant="outlined" onClick={handleClickOpen}>
                add disease
              </Button>   <DiseaseAdditionForm handleClose={handleClose} employeeId={row.id} open={open} /> </TableCell>


              <TableCell><Button variant="outlined" onClick={handleClickOpen}>
                add vaccine   </Button></TableCell>
            </TableRow>

          ))}
        </TableBody>
      </Table>
    </TableContainer>

  );
}

