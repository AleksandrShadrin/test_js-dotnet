import { Text } from "@mantine/core";

import Logo from "../../assets/full_logo.svg?react";
import classes from "./Footer.module.css";

export default function Footer() {
	return (
		<footer className={classes.footer}>
			<Logo className={classes.logo} fill="gray"></Logo>
			<Text c="var(--mantine-color-gray-5)">DIRECTUM, 2019</Text>
		</footer>
	);
}
