import { Table, TableCell, TableContainer, TableHead, TableRow, Paper, TableBody, Popover, Typography } from "@mui/material";
import { useState } from "react";

export default function EmplVaccinations({ emplVaccinations }) {
    const [popoverOpen, setPopoverOpen] = useState(false);
    const [anchorEl, setAnchorEl] = useState(null);

    const onHover = (event) => {
        setAnchorEl(event.currentTarget);
        setPopoverOpen(true);
    }

    const onHoverLeave = () => {
        setPopoverOpen(false);
        setAnchorEl(null);

    }
    return (
        <>
            <Typography
                aria-owns={popoverOpen ? 'mouse-over-popover' : undefined}
                aria-haspopup="true"
                onMouseEnter={onHover}
            >
                Vaccinations
            </Typography>
            <Popover open={popoverOpen} anchorEl={anchorEl} id="mouse-over-popover"
                anchorOrigin={{
                    vertical: 'bottom',
                    horizontal: 'left',
                }}
                transformOrigin={{
                    vertical: 'top',
                    horizontal: 'left',
                }}
                onClose={onHoverLeave}
            >
                <TableContainer component={Paper}>
                    <Table sx={{ minWidth: 100 }} aria-label="simple table">
                        <TableHead>
                            <TableRow>
                                <TableCell>Vaccination Name </TableCell>
                                <TableCell align="right">Date</TableCell>
                                <TableCell align="right">Number</TableCell>
                            </TableRow>
                        </TableHead>
                    </Table>
                    <TableBody>
                        {
                            emplVaccinations.map(e => (<TableRow>
                                <TableCell>{e.vaccination.manufacturer}</TableCell>
                                <TableCell>{e.date}</TableCell>
                                <TableCell>{e.vaccinationNum}</TableCell>
                            </TableRow>))
                        }
                    </TableBody>
                </TableContainer>
            </Popover>
        </>
    );
}