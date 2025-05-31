import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import { HomePage } from "../pages/HomePage/HomePage";
import { CreateCvPage } from "../pages/CreateCvPage/CreateCvPage";
import { LoginPage } from "../pages/LoginPage/LoginPage";
import { ProtectedRoute } from "./protectedRoute";
import { FeedPage } from "../pages/FeedPage/FeedPage";
import { RegisterPage } from "../pages/RegisterPage/RegisterPage";

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
                element: 
                <ProtectedRoute>
                    <CreateCvPage/>
                </ProtectedRoute>
                    
            },
             {
                path:"/register",
                element:<RegisterPage/>
            },
            {
                path:"/login",
                element:<LoginPage/>
            },
            {
                path:"/jobOffers",
                element:<FeedPage/>
            },
            {
                path:"*",
                element:<h1>This Page Doesn't exist</h1>
            }
        ],
    }
])
