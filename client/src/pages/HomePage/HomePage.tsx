import React from 'react'
import './_homepage.scss';

export const HomePage:React.FC  = () => {
  return (
    <>
      <main>
        <div className="h1-p-button">
            <h2>
              Its not about procents <br/> but about <span>Chance</span>
            </h2>
            <p> <b>JOBst</b> is a recruitment platform designed to streamline the hiring  process by using an AI algorithm to match students with job  opportunities. Inspired by dating apps.</p>
            <button className='button-hero-section'>Apply for job</button>
              <input type="text" name="UserName" id="Text" placeholder="UserName" />
              <input type="text" name="Email" id="Text" placeholder="Email" />
              <select name="select" id="">
                <option value="Val1">Val1</option>
                <option value="Val2">Val2</option>
                <option value="Val3">Val3</option>
              </select>
              <input type="password" name="Text" id="Text" placeholder="Text" />
              <input className='cv' type="text" name="Text" id="Text" placeholder="Text" />
              <fieldset name="tel">
                <select name="endtel" id="">
                  <option value="">+40</option>
                  <option value="">+373</option>
                </select>
                <input type="tel" id="phone" name="phone" placeholder="123-45-678" pattern="[0-9]{3}-[0-9]{2}-[0-9]{3}" required/>
              </fieldset>
              <fieldset name='gender'>
                <legend>Choose Gender</legend>
                <label htmlFor="male">
                  <div>
                   <input name='gender' id='male' type="radio" value='Male'/>
                    <div className='checker'></div>
                  </div>
                  Male
                </label>
                <label htmlFor="female">
                  <div>
                   <input name='gender' id='female' type="radio" value='Female'/>
                    <div className='checker'></div>
                  </div>
                  Femael
                </label>
              </fieldset>
              <fieldset name='language'>
                <legend>Choose Level</legend>
                <label htmlFor="A1">
                   <input name='level' id='A' type="radio" value='A1'/>
                 <div className='checker'>A1</div>
                </label>
                <label htmlFor="A2">
                   <input name='level' id='A2' type="radio" value='A2'/>
                 <div className='checker'>A2</div>
                </label>
                <label htmlFor="B1">
                   <input name='level' id='B1' type="radio" value='B1'/>
                 <div className='checker'>B1</div>
                </label>
              </fieldset>
              <input type="date" name="date" id="date" />
        </div>
      </main>
    </>
  )
}
