import React from 'react'
import { Link } from 'react-router-dom'
import { useAuth } from '../../../Context/useAuth'

export const Header:React.FC = ()=> {
  const {isLoggedIn} = useAuth();
  console.log(isLoggedIn());
  return isLoggedIn()? 
  (
    <header>
    <Link to="/"></Link>
    <nav>
      <Link to="/jobOffers">Login</Link>
       <Link to="/yourCv">Login</Link>
    </nav>
  </header>
  )
  :
  (
  <header>
    <Link to="/"></Link>
    <nav>
      <Link to="/login">Login</Link>
    </nav> 
  </header>
  )
}
