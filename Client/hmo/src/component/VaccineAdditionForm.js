import * as React from 'react';
import { useState } from "react";

import Box from '@mui/material/Box';
import dayjs from 'dayjs';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import './AdditionForm.css'

import Dialog from '@mui/material/Dialog';
import Button from '@mui/material/Button';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';


export default function VaccineAdditionForm({ handleClose, open, employeeId }) {
    const [contactInfo, setContactInfo] = useState({
        employeeId,
        positiveResult: "",
        recovery: ""
    });


    const handleChangeDate = (x, field) => {
        let value = JSON.stringify(x);
        setContactInfo({ ...contactInfo, [field]: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(contactInfo);
        setContactInfo({ VaccinationDate: "", positiveResult: "", });
        handleClose();
    };

    return (
        <Dialog open={open} onClose={handleClose}>
            <DialogTitle>Subscribe</DialogTitle>
            <DialogContent>
                <Box onSubmit={handleSubmit}
                    component="form"
                    sx={{
                        '& > :not(style)': { m: 1, width: '25ch' },
                    }}
                    noValidate
                    autoComplete="off"
                >
                    <div className='box'>

                        <LocalizationProvider dateAdapter={AdapterDayjs}>

                            <DatePicker name='VaccinationDate' label="born date" color="secondary" defaultValue={dayjs('2022-05-08')}
                                focused onChange={(x) => handleChangeDate(x, 'recovery')} />

                        </LocalizationProvider>

                    </div>

                </Box>
            </DialogContent>
            <DialogActions>
                <Button onClick={handleClose}>Cancel</Button>
                <Button onClick={handleSubmit} >Save</Button>
            </DialogActions>
        </Dialog>
    );
}

