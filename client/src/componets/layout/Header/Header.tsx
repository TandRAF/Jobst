import React from 'react'
import { Link } from 'react-router-dom'

export const Header:React.FC = ()=> {
  return (
  <header>
    <Link to="/"></Link>
    <nav>
      <Link to="/login">Login</Link>
    </nav>
    
  </header>
  )
}
