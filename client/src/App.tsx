import { Outlet } from "react-router-dom";
import { Header } from "./componets/layout/Header/Header";
import { Footer } from "./componets/layout/Footer";
import { UserProvider } from "./Context/useAuth";

function App() {
  return (
    <>
      <UserProvider>
        <Header/>
        <Outlet/>
        <Footer/>
      </UserProvider>
    </>
  );
}

export default App;

