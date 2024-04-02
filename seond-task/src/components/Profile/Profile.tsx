import { Avatar, Flex, Text } from "@mantine/core";

import classes from "./Profile.module.css";

type Props = {
	image: React.ReactNode;
	size: string;
	title: string;
	content: string;
	width: string;
};

export default function Profile({ image, size, title, content, width }: Props) {
	return (
		<Flex direction="column" gap="sm" align="center" w={width}>
			<Avatar size={size} className={classes.body}>
				{image}
			</Avatar>
			<Text fw="bold" size="26px" ta="center">
				{title}
			</Text>
			<Text fs="italic" size="lg" ta="center">
				{content}
			</Text>
		</Flex>
	);
}
