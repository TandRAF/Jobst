import { RouterProvider, createBrowserRouter, RouteObject } from "react-router-dom";
import { useAuth } from "../componets/provider/authProvider";
import { ProtectedRoute } from "./protectedRoute";
import Login from "../pages/Login/login";
import Logout from "../pages/Logout/logout";

const Routes: React.FC = () => {
  const { token } = useAuth();

  // Public routes
  const routesForPublic: RouteObject[] = [
    {
      path: "/service",
      element: <div>Service Page</div>,
    },
    {
      path: "/about-us",
      element: <div>About Us</div>,
    },
  ];

  // Authenticated-only routes
  const routesForAuthenticatedOnly: RouteObject[] = [
    {
      path: "/",
      element: <ProtectedRoute />,
      children: [
        {
          path: "/",
          element: <div>User Home Page</div>,
        },
        {
          path: "/profile",
          element: <div>User Profile</div>,
        },
        {
          path: "/logout",
          element: <Logout/>
        },
      ],
    },
  ];

  // Non-authenticated-only routes
  const routesForNotAuthenticatedOnly: RouteObject[] = [
    {
      path: "/",
      element: <div>Home Page</div>,
    },
    {
      path: "/login",
      element: <Login/>
    },
  ];

  // Combine all routes conditionally
  const router = createBrowserRouter([
    ...routesForPublic,
    ...(!token ? routesForNotAuthenticatedOnly : []),
    ...routesForAuthenticatedOnly,
  ]);

  return <RouterProvider router={router} />;
};

export default Routes;
