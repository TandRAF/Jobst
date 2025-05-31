import React from 'react'
import './_homepage.scss';
import { CvImage } from '../../assets/CvImage';
import { useNavigate } from 'react-router-dom';
export const HomePage:React.FC  = () => {
  const navigate = useNavigate();
  return (
    <>
      <main>
        <div className="h1-p-button">
            <h2>
              Its not about percentages <br/> but about <span>Chance</span>
            </h2>
            <p> <b>JOBst</b> is a recruitment platform designed to streamline the hiring  process by using an AI algorithm to match students with job  opportunities. Inspired by dating apps.</p>
            <button 
            onClick={()=>navigate("/create-cv/0/0")}
            className='button-hero-section'>Apply for job</button>
            <CvImage/>
        </div>
      </main>
    </>
  )
}
