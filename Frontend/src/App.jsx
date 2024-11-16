import { BrowserRouter, Route, Routes } from 'react-router-dom'
import './App.css'
import Login from "./Auth/Login";
import Dashboard from "./Dashboard/Dashboard.jsx";

function App() {
  return (
    <>
       <BrowserRouter>
         <Routes>
           <Route path="/" element={<Login />} />
           <Route path="/dashboard" element={<Dashboard />} />
         </Routes>
       </BrowserRouter>
    </>
  )
}

export default App
