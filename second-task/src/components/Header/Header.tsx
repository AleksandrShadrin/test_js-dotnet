import { Flex, Title, Text } from "@mantine/core";

import classes from "./Header.module.css";
import Logo from "../../assets/logo.svg?react";

export default function Header() {
	return (
		<Flex className={classes.header} direction="column" align="center" gap="lg">
			<Flex
				className={classes["logo-container"]}
				justify="center"
				align="center"
			>
				<Logo height="75px" fill="white" />
			</Flex>
			<Title order={1} ta="center" c="white" className={classes.title}>
				Название мероприятия
			</Title>
			<Text fw="bold" size="lg" c="white">
				4 МАЯ 2049
			</Text>
			<Text fw="bold" size="lg" c="white">
				в самом сердце страны
			</Text>
		</Flex>
	);
}
