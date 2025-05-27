import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import { HomePage } from "../pages/HomePage/HomePage";
import Register from "../pages/RegisterPage/Register";
import { FeedPage } from "../pages/FeedPage/FeedPage";

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
                path:"/feed",
                element: <FeedPage/>
            },
             {
                path:"/register",
                element:<Register/>
            }
        ],
    }
])
