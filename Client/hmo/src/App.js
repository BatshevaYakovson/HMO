import logo from '../src/images/logo.jpg'
import { useState } from "react";
import './App.css';
import EmployeeAdditionForm from './component/EmployeeAdditionForm';
import EmployeeLists from './component/EmployeeLists';
import Button from '@mui/material/Button';


function App() {
  const [open, setOpen] = useState(false);

  const handleClickOpen = () => {
    setOpen(true);
  };

  const handleClose = () => {
    setOpen(false);
  };

  return (
    <div className="app">
      <img src={logo} width={100} height={100} />
      <Button variant="outlined" onClick={handleClickOpen}>
        add user to the HMO
      </Button>

      <EmployeeLists />
      <EmployeeAdditionForm handleClose={handleClose} open={open}/>
    </div>
  );
}

export default App;
