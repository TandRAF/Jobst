import React from 'react'
import Login from '../../componets/Auth/Login/Login'
import "./_loginPage.scss";

export const LoginPage = () => {
  return (
    <div className='login-page'>
      <h3>Login</h3>
      <Login/>
    </div>
  )
}
