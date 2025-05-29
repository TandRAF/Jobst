import "./_statusBar.scss";
import { ProfileIcon,WorkExperienceIcon,LanguageIcon, EducationIcon } from "../../assets/icons";

type prop = {
    index:number
}

export const StatusBar = (Props:prop) => {
    const statusIcons = [
    {
        index:1,
        Element: <ProfileIcon/>
    },
        {
        index:2,
         Element: <EducationIcon/>
    },
        {
        index:3,
         Element: <WorkExperienceIcon/>
    },
        {
        index:4,
         Element: <LanguageIcon/>
    }
]
  return (
    <section className='status-bar'>
            {statusIcons.map((el)=>{
                return el.index != statusIcons.length? 
                (
                    <>
                    <div
                    className={`Icon ${el.index<=Props.index?"active":" "}`}
                     key={""+el.index}>
                        {el.Element}
                     </div>
                     <span className={el.index<Props.index?"active":" "}></span>
                    </>
                ):
                (
                    <div
                    className={`Icon ${el.index<=Props.index?"active":" "}`}
                     id={""+ el.index}>
                         {el.Element}
                     </div>
                )
            })}
    </section>
  )
}
