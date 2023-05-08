import * as React from 'react';
import { useState } from "react";

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import './EmployeeAdditionForm.css'
import Dialog from '@mui/material/Dialog';
import Button from '@mui/material/Button';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';

export default function EmployeeAdditionForm({ handleClose ,open}) {
    const [contactInfo, setContactInfo] = useState({
        fullname: "",
        id: "",
        fullAddress: "",
        cellphone: "",
        phone: "",
        bornDate: ""
    });

    const handleChange = (event) => {
        console.log(contactInfo);

        setContactInfo({ ...contactInfo, [event.target.name]: event.target.value });
    };
    const handleChangeDate = (x) => {
       
        let value=JSON.stringify(x);
        setContactInfo({ ...contactInfo, bornDate: value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(contactInfo);
        setContactInfo({ fullname: "", id: "", fullAddress: "", cellphone: "", phone: "", bornDate: "" });
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
                        <TextField name='fullname'  label="full name" color="secondary" value={contactInfo.fullname} focused onChange={handleChange} />
                        <TextField name="id" label="id" type='tel' color="secondary" value={contactInfo.id} focused onChange={handleChange} />
                        <TextField name='fullAddress' label="full address" color="secondary" value={contactInfo.fullAddress} focused onChange={handleChange} />
                        <TextField name='cellphone' type='tel' label="cellphone" color="secondary" value={contactInfo.cellphone} focused onChange={handleChange} />
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

