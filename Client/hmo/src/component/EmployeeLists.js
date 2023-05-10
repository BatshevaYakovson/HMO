import * as React from 'react';
import Table from '@mui/material/Table';
import TableBody from '@mui/material/TableBody';
import TableCell from '@mui/material/TableCell';
import TableContainer from '@mui/material/TableContainer';
import TableHead from '@mui/material/TableHead';
import TableRow from '@mui/material/TableRow';
import Paper from '@mui/material/Paper';
import Button from '@mui/material/Button';
import { useState, useEffect } from 'react';
import DiseaseAdditionForm from './DiseaseAdditionForm';
import EmplVaccinationAdditionForm from './EmplVaccinationAdditionForm'



export default function EmployeeLists() {
  const [employees, setEmployees] = useState([]);
  const [open, setOpen] = useState(false);
  const [openVaccine, setVaccineOpen] = useState(false);

  useEffect(() => {
    const fetchData = async () => {
      try {
        const res = await fetch('https://localhost:7197/api/Employee', { mode: 'cors' });
        const json = await res.json();
        console.log(json);
        setEmployees(json);
      }
      catch (e) {
        console.log(e);
      }

    }
    fetchData();

  }, []);

  const handleClickOpen = (popupType) => {
    if (popupType === 'vaccine') {
      setVaccineOpen(true);
    }
    else {
      setOpen(true);
    }
  };

  const handleClose = (popupType) => {
    if (popupType === 'vaccine') {
      setVaccineOpen(false);
    }
    else {
      setOpen(false);
    }
  };


  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Name </TableCell>
            <TableCell align="right">Id</TableCell>
            <TableCell align="right">Address</TableCell>
            <TableCell align="right">Phone</TableCell>
            <TableCell align="right">CellPhone</TableCell>
            <TableCell align="right">Born Date</TableCell>
            <TableCell align='right'>Disease details</TableCell>
            <TableCell align='right'>Vaccine details</TableCell>

          </TableRow>
        </TableHead>
        <TableBody>
          {employees.map((row) => (
            <TableRow
              key={row.name}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">{row.fullName}</TableCell>
              <TableCell align="right">{row.employeeId}</TableCell>
              <TableCell align="right">{row.address}</TableCell>
              <TableCell align="right">{row.phone}</TableCell>
              <TableCell align="right">{row.cellPhone}</TableCell>
              <TableCell align="right">{row.bornDate}</TableCell>
              <TableCell align='right'>
                <Button variant="outlined" onClick={handleClickOpen}>  add disease </Button>
                <DiseaseAdditionForm handleClose={handleClose} employeeId={row.employeeId} open={open} />
              </TableCell>


              <TableCell><Button variant="outlined" onClick={() => handleClickOpen('vaccine')}>
                add vaccine   </Button>
                <EmplVaccinationAdditionForm handleClose={() => handleClose('vaccine')} employeeId={row.employeeId} open={openVaccine} />
              </TableCell>
            </TableRow>

          ))}
        </TableBody>
      </Table>
    </TableContainer>

  );
}

