import './App.css'
import Auth from './Auth/Auth'
import { Navigate, Route, Routes } from 'react-router-dom'
import FloatingSharpe from '../components/FloatingSharpe'
import { Children } from 'react'
import { useAuthStore } from './Protected/ProtectedRoute'

function App() {
 const ProtectedRoute = ({Children}) => {
    const { isAuthenticated, user } = useAuthStore();

    if (!isAuthenticated) {
        return <Navigate to="/Auth" replace />
    }

    return Children
 }


  return (
    <>
       <div
			className='min-h-screen bg-gradient-to-br
    from-gray-900 via-green-900 to-emerald-900 flex items-center justify-center relative overflow-hidden'
		>
			<FloatingSharpe color='bg-green-500' size='w-64 h-64' top='-5%' left='10%' delay={0} />
			<FloatingSharpe color='bg-emerald-500' size='w-48 h-48' top='70%' left='80%' delay={5} />

       <Routes>
        <Route path='/Auth' element={<Auth />} />
        <Route path='*' element={<Navigate to="/Auth" />} />
        <Route path='/' element={<ProtectedRoute>

        </ProtectedRoute>} />
       </Routes>

       </div>
    </>
  )
}

export default App
