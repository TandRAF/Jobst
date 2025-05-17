import { createBrowserRouter } from "react-router-dom";
import App from "../App";
import { HomePage } from "../pages/HomePage/homePage";
import { FeedPage } from "../pages/FeedPage/feedPage";

export const router = createBrowserRouter([
    {
        path: "/",
        element: <App/>,
        children:[
            {
                path:"/home",
                element: <HomePage/>
            },
            {
                path:"/feed",
                element: <FeedPage/>
            }
        ],
    }
])
