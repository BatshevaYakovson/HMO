import * as React from 'react';
import { useState, useEffect } from "react";

import Box from '@mui/material/Box';
import TextField from '@mui/material/TextField';
import dayjs from 'dayjs';
import { DemoContainer } from '@mui/x-date-pickers/internals/demo';
import { LocalizationProvider } from '@mui/x-date-pickers/LocalizationProvider';
import { AdapterDayjs } from '@mui/x-date-pickers/AdapterDayjs';
import { DatePicker } from '@mui/x-date-pickers/DatePicker';
import './AdditionForm.css'
import InputLabel from '@mui/material/InputLabel';

import Dialog from '@mui/material/Dialog';
import Button from '@mui/material/Button';
import DialogActions from '@mui/material/DialogActions';
import DialogContent from '@mui/material/DialogContent';
import DialogTitle from '@mui/material/DialogTitle';
import Select from '@mui/material/Select';
import MenuItem from '@mui/material/MenuItem';

export default function EmplVaccinationAdditionForm({ employeeId }) {
    const [open, setOpen] = useState(false);
    const [vaccinations, setVaccinations] = useState([])
    const [vaccinationInfo, setVaccinationInfo] = useState({
        vaccinationId: "",
        employeeId,
        date: ""
    });
    const handleClickOpen = () => {

        setOpen(true);

    };

    const handleClose = () => {

        setOpen(false);

    };
    useEffect(() => {
        const fetchData = async () => {
            try {
                const res = await fetch('https://localhost:7197/api/Vaccination', { mode: 'cors' });
                const json = await res.json();
                console.log(json);
                setVaccinations(json);
            }
            catch (e) {
                console.log(e);
            }

        }
        fetchData();

    }, []);

    const handleChangeDate = (x, field) => {
        let value = new Date(x).toISOString();
        setVaccinationInfo({ ...vaccinationInfo, [field]: value });
    };

    const handleChange = (event) => {
        setVaccinationInfo({ ...vaccinationInfo, vaccinationId: event.target.value });
    };

    const handleSubmit = (event) => {
        event.preventDefault();
        console.log(vaccinationInfo);
        setVaccinationInfo({ date: "" });
        handleClose();
        createEmplVaccination();
    };

    const createEmplVaccination = () => {
        const requestOption = {
            method: 'POST',
            headers: { 'Content-Type': 'application/json' },
            body: JSON.stringify(vaccinationInfo),
            mode: 'cors'
        }
        fetch('https://localhost:7197/api/EmplVaccination', requestOption).then(async res => {
            const data = await res.json();

            console.log(data)
        }).catch(e => console.log(e))
    }
    return (
        <><Button variant="outlined" onClick={() => handleClickOpen('vaccine')}>
            add vaccine   </Button>
            <Dialog open={open} onClose={handleClose}>
                <DialogTitle>Add vaccination for employee</DialogTitle>
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

                            <InputLabel id="selectVaccination">select vaccination</InputLabel>
                            <Select

                                labelId="selectVaccination"
                                id="selectVaccination"
                                value={vaccinationInfo.vaccinationId}
                                label="vaccination"
                                onChange={handleChange}
                            >
                                {vaccinations.map(v => <MenuItem value={v.vaccinationId}>{v.manufacturer}</MenuItem>)}


                            </Select>
                            <LocalizationProvider dateAdapter={AdapterDayjs}>
                                <DatePicker name='date' label="date" color="secondary" focused
                                    onChange={(x) => handleChangeDate(x, 'date')} />

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

