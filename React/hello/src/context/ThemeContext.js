import { createContext} from "react";

export const ThemeContext = createContext();

export const toggleTheme = (theme, setTheme) => {
    setTheme(theme === 'light' ? 'dark' : 'light')
}