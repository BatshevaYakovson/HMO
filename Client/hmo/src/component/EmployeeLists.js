import * as React from 'react';
import { Table, TableBody, TableCell, TableContainer, TableHead, TableRow, Paper, Button, Typography } from '@mui/material';
import { useState, useEffect } from 'react';
import DiseaseAdditionForm from './DiseaseAdditionForm';
import EmplVaccinations from './EmplVaccinations';
import EmplVaccinationAdditionForm from './EmplVaccinationAdditionForm';
import formatDate from '../helper';


export default function EmployeeLists() {
  const [employees, setEmployees] = useState([]);

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

  return (
    <TableContainer component={Paper}>
      <Table sx={{ minWidth: 650 }} aria-label="simple table">
        <TableHead>
          <TableRow>
            <TableCell>Name </TableCell>
            <TableCell>Id</TableCell>
            <TableCell>Address</TableCell>
            <TableCell>Phone</TableCell>
            <TableCell>CellPhone</TableCell>
            <TableCell >Born Date</TableCell>
            <TableCell >Disease details</TableCell>
            <TableCell>Vaccine details</TableCell>

          </TableRow>
        </TableHead>
        <TableBody>
          {employees.map((row) => (
            <TableRow
              key={row.name}
              sx={{ '&:last-child td, &:last-child th': { border: 0 } }}
            >
              <TableCell component="th" scope="row">{row.fullName}</TableCell>
              <TableCell >{row.employeeId}</TableCell>
              <TableCell>{row.address}</TableCell>
              <TableCell>{row.phone}</TableCell>
              <TableCell>{row.cellPhone}</TableCell>
              <TableCell>{formatDate(row.bornDate)}</TableCell>
              <TableCell>
                {row.disease ? (<>
                  <Typography>Positive result Date: {formatDate(row.disease.positiveResult)}</Typography>
                  <Typography>Recovery Date: {formatDate(row.disease.recovery)}</Typography>
                </>) :

                  (
                    <DiseaseAdditionForm employeeId={row.employeeId} />)
                }
              </TableCell>


              <TableCell>
                {row.emplVaccinations?.length ? <> <EmplVaccinations emplVaccinations={row.emplVaccinations} ></EmplVaccinations> </> : <></>
                }
                {(row.emplVaccinations?.length || 0) < 4 ? <> <EmplVaccinationAdditionForm employeeId={row.employeeId} /> </> : <></>
                }
              </TableCell>
            </TableRow>

          ))}
        </TableBody>
      </Table>
    </TableContainer>

  );
}

