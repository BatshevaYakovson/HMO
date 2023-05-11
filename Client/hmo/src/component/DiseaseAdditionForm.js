import * as React from 'react';
import { useState } from "react";

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
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

export default function DiseaseAdditionForm({ employeeId }) {
    console.log(employeeId);
    const [open, setOpen] = useState(false);

    const [contactInfo, setContactInfo] = useState({
        employeeId,
        positiveResult: "",
        recovery: ""
    });
    const handleClickOpen = (popupType) => {

        setOpen(true);

    };

    const handleClose = (popupType) => {

        setOpen(false);

    };

    const handleChangeDate = (x, field) => {

        let value = new Date(x).toISOString();
        if (field === 'positiveResult')
            setContactInfo({ ...contactInfo, positiveResult: value });
        else
            setContactInfo({ ...contactInfo, recovery: value });

    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(contactInfo);
        setContactInfo({ recovery: "", positiveResult: "", });
        handleClose();
        createDisease();
    };

    const createDisease = () => {
        const requestOption = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(contactInfo),
            mode: 'cors'
        }
        fetch('https://localhost:7197/api/Disease', requestOption).then(async res => {
            const data = await res.json();

            console.log(data)
        }).catch(e => console.log(e))
    }
    return (
        <><Button variant="outlined" onClick={handleClickOpen}>  add disease </Button>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Add disease</DialogTitle>
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
                                <DatePicker name='positiveResult' label="Positive result" color="secondary" focused
                                    onChange={(x) => handleChangeDate(x, 'positiveResult')} />
                                <DatePicker name='recovery' label="recovery date" color="secondary"
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
        </>
    );
}

