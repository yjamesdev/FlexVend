import "./App.css";
import Auth from "./Auth/Auth";
import { Navigate, Route, Routes, useLocation } from "react-router-dom";
import FloatingSharpe from "../components/FloatingSharpe";
import { useAuthStore } from "./Protected/ProtectedRoute";
import Dashboard from "./Dashboard/Dashboard";
import Sidebar from "./Dashboard/Sidebar/Sidebar.jsx";
import Home from "./Home/Home.jsx";

function App() {
  const location = useLocation();
  const ProtectedRoute = ({ Children }) => {
    const { isAuthenticated, user } = useAuthStore();

    if (!isAuthenticated) {
      return <Navigate to="/Auth" replace />;
    }

    return Children;
  };

  return (
    <>
      <div className="flex h-screen bg-gray-900 text-gray-100 overflow-hidden">
        <div className="fixed inset-0 z-0">
          <div className="absolute inset-0 bg-gradient-to-br from-gray-900 via-gray-800 to-gray-900 opacity-80" />
          <div className="absolute inset-0 backdrop-blur-sm" />
        </div>

        <FloatingSharpe
          color="bg-green-500"
          size="w-64 h-64"
          top="-5%"
          left="10%"
          delay={0}
        />
        <FloatingSharpe
          color="bg-emerald-500"
          size="w-48 h-48"
          top="70%"
          left="80%"
          delay={5}
        />
        {location.pathname !== "/Auth" && <Sidebar />}

        <div className={`flex-1 ${location.pathname === '/Auth' ? 'flex items-center justify-center' : ''}`}>
        <Routes>
          <Route path="/Auth" element={<Auth />} />
          <Route path="/Dashboard" element={<Dashboard />} />
          <Route path="*" element={<Navigate to="/Auth" />} />
          <Route path="/" element={<Home />} />
        </Routes>
        </div>
      </div>
    </>
  );
}

export default App;
