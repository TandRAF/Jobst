import { Outlet } from "react-router-dom";
import { Header } from "./componets/layout/Header/Header";
import { Footer } from "./componets/layout/Footer";

function App() {
  return (
    <>
      <Header/>
      <Outlet/>
      <Footer/>
    </>
  );
}

export default App;

