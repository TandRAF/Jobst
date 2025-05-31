import React from 'react'
import { Link } from 'react-router-dom'
import { useAuth } from '../../../Context/useAuth'
import { JobstLogo,  ProfileIcon } from '../../../assets/icons'
import "./_header.scss"

export const Header:React.FC = ()=> {
  const {isLoggedIn} = useAuth();

  console.log(isLoggedIn());
  
  return (
    <header className="header">
      <Link to="/" className="logo">
        <JobstLogo />
        <span>Jobst</span>
      </Link>
      <nav className="nav">
        {isLoggedIn() ? (
          <>
            <Link to="/jobOffers">Job Offers</Link>
            <Link to="/profile" className="profile-icon">
              <ProfileIcon />
            </Link>
          </>
        ) : (
          <Link to="/login" className="login-button">
            Login
          </Link>
        )}
      </nav>
    </header>
  )
}
