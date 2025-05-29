import "./_createCvPage.scss";
import { StatusBar } from "../../componets/statusBar/StatusBar";
import { getforms } from "../../assets/forms";
import { useParams } from 'react-router-dom';

export const CreateCvPage = () => {
  const forms = getforms();
  const navId = useParams();
  console.log(navId);
  return (
    <section className="ceate-cv-page">
        <div className="form-status-bar-block">
            <h3>{forms[Number(navId.formId)].Title}</h3>
            {forms[Number(navId.formId)].index == 5? 
            <></>
            :
            <StatusBar index={forms[Number(navId.formId)].index}></StatusBar>}
            {forms[Number(navId.formId)].Element}
        </div>
    </section>
  )
}
