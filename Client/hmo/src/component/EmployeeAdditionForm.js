import * as React from 'react';
import { useState, useEffect } from "react";
import axios from 'axios'
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

export default function EmployeeAdditionForm({ handleClose, open }) {
    const [contactInfo, setContactInfo] = useState({
        EmployeeId: "",
        fullName: "",
        address: "",
        cellPhone: "",
        phone: "",
        bornDate: ""
    });


    const handleChange = (event) => {
        setContactInfo({ ...contactInfo, [event.target.name]: event.target.value });
    };
    const handleChangeDate = (x) => {
        let value = new Date(x).toISOString();
        setContactInfo({ ...contactInfo, bornDate: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(contactInfo);
        setContactInfo({ fullName: "", EmployeeId: "", address: "", cellPhone: "", phone: "", bornDate: "" });
        handleClose();
        createUser();

    };
    const createUser = () => {
        const requestOption = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(contactInfo),
            mode: 'cors'
        }
        fetch('https://localhost:7197/api/Employee', requestOption).then(async res => {
            const data = await res.json();

            console.log(data)
        }).catch(e => console.log(e))
    }
    return (
        <Dialog open={open} onClose={handleClose}>
            <DialogTitle>Add employee</DialogTitle>
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
                        <TextField name='fullName' label="full name" color="secondary" value={contactInfo.fullName} focused onChange={handleChange} />
                        <TextField name="EmployeeId" label="id" type='tel' color="secondary" value={contactInfo.EmployeeId} focused onChange={handleChange} />
                        <TextField name='address' label="full address" color="secondary" value={contactInfo.address} focused onChange={handleChange} />
                        <TextField name='cellPhone' type='tel' label="cellPhone" color="secondary" value={contactInfo.cellPhone} focused onChange={handleChange} />
                        <TextField name='phone' type='tel' label="phone" color="secondary" value={contactInfo.phone} focused onChange={handleChange} />
                        <LocalizationProvider dateAdapter={AdapterDayjs}>
                            <DemoContainer components={['DatePicker', 'DatePicker']}>
                                <DatePicker name='bornDate' label="born date" color="secondary" defaultValue={dayjs('2022-05-08')} focused onChange={handleChangeDate} />

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

