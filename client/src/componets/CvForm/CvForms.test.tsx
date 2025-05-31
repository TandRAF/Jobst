import React from "react";
import { render, screen, fireEvent } from "@testing-library/react";
import {CreateCv} from "./CvForm";
import { BrowserRouter } from "react-router-dom";

import * as ApiModule from "../../__mocks__/api";
console.log(ApiModule);

jest.mock("../../api", () => ({
  createCv: jest.fn(),
}));

const renderWithRouter = (ui: React.ReactElement) => {
  return render(<BrowserRouter>{ui}</BrowserRouter>);
};

describe("CreateCv Component", () => {
  beforeEach(() => {
    renderWithRouter(<CreateCv />);
  });

  test("renders all form fields and submit button", () => {
    expect(screen.getByLabelText(/^name$/i)).toBeInTheDocument();
    expect(screen.getByLabelText(/^surname$/i)).toBeInTheDocument();
    expect(screen.getByLabelText(/^email$/i)).toBeInTheDocument();
    expect(screen.getByLabelText(/^phone number$/i)).toBeInTheDocument();
    expect(screen.getByLabelText(/^summary$/i)).toBeInTheDocument();
    expect(screen.getByRole("button", { name: /sign up/i })).toBeInTheDocument();
  });

  test("updates form inputs correctly", () => {
    const nameInput = screen.getByLabelText(/^name$/i);
    fireEvent.change(nameInput, { target: { value: "Alice" } });
    expect(nameInput).toHaveValue("Alice");

    const surnameInput = screen.getByLabelText(/^surname$/i);
    fireEvent.change(surnameInput, { target: { value: "Smith" } });
    expect(surnameInput).toHaveValue("Smith");

    const emailInput = screen.getByLabelText(/^email$/i);
    fireEvent.change(emailInput, { target: { value: "alice@example.com" } });
    expect(emailInput).toHaveValue("alice@example.com");

    const phoneInput = screen.getByPlaceholderText("123456789");
    fireEvent.change(phoneInput, { target: { value: "123456789" } });
    expect(phoneInput).toHaveValue("123456789");

    const summaryInput = screen.getByLabelText(/^summary$/i);
    fireEvent.change(summaryInput, { target: { value: "Short description..." } });
    expect(summaryInput).toHaveValue("Short description...");
  });
});
