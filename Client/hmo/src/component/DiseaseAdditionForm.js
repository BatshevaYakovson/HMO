import * as React from 'react';
import { useState } from "react";

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import './AdditionForm.css'

import Dialog from '@mui/material/Dialog';
import Button from '@mui/material/Button';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';

export default function DiseaseAdditionForm({ handleClose, open, employeeId }) {
    const [contactInfo, setContactInfo] = useState({
        employeeId,
        positiveResultDate: "",
        recoveryDate: ""
    });


    const handleChangeDate = (x, field) => {

        let value = new Date(x).toISOString();
        if (field === 'positiveResultDate')
            setContactInfo({ ...contactInfo, positiveResultDate: value });
        else
            setContactInfo({ ...contactInfo, recoveryDate: value });

    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(contactInfo);
        setContactInfo({ recoveryDate: "", positiveResultDate: "", });
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
                            <DemoContainer components={['DatePicker', 'DatePicker']}>
                                <DatePicker name='positiveResultDate' label="Positive result" color="secondary" defaultValue={dayjs('2022-05-08')} focused
                                    onChange={(x) => handleChangeDate(x, 'positiveResultDate')} />
                                <DatePicker name='recoveryDate' label="recovery date" color="secondary" defaultValue={dayjs('2022-05-08')}
                                    focused onChange={(x) => handleChangeDate(x, 'recoveryDate')} />

                            </DemoContainer>
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

