import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import { HomePage } from "../pages/HomePage/HomePage";
import Register from "../componets/Auth/Register/Register";
import { CreateCvPage } from "../pages/CreateCvPage/CreateCvPage";
import Login from"../componets/Auth/Login/Login"

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children:[
            {
                path:"",
                element: <HomePage/>
            },
            {
                path:"/create-cv/:cvId/:formId",
                element: <CreateCvPage/>
            },
             {
                path:"/register",
                element:<Register/>
            },
            {
                path:"/login",
                element:<Login/>
            },
            {
                path:"*",
                element:<h1>This Page Doesn't exist</h1>
            }
        ],
    }
])
