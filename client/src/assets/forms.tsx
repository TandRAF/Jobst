import { CreateCv } from "../componets/CvForm/CvForm"
import { CreateEducation } from "../componets/EducationForm/EducationForm"
import { CreateWork } from "../componets/WorkForm/WorkForm"
import { CreateLanguage } from "../componets/LanguageForm/LanguageForm"
import {Modal} from "../componets/Modal/Modal"


export const getforms = ()=>[
    {
        index:1,
        Title:"Add Personal Information",
        Element:<CreateCv/>
    },
        {
        index:2,
        Title:"Add Personal Information",
        Element:<CreateEducation/>
    },
    {
        index:3,
        Title:"Add Personal Information",
        Element:<CreateWork/>
    },
        {
        index:4,
        Title:"Add Personal Information",
        Element:<CreateLanguage/>
    },
        {
        index:5,
        Title:"Congratulations, your CV is Created",
        Element:<Modal/>
    }
    
]