import { Flex, Title } from "@mantine/core";
import avatarSrc from "../../assets/avatar.png";
import Profile from "../Profile/Profile";

export default function Speakers() {
	const profile = (
		<Profile
			width="242px"
			image={<img width="200px" height="200px" src={avatarSrc} />}
			content="уморительный, остроумный и обоятельный сыщик"
			size="135px"
			title="Детектив пикачу"
		></Profile>
	);

	return (
		<>
			<Title
				w="100%"
				ta="center"
				order={1}
				fw="bold"
				py="50px"
				visibleFrom="md"
			>
				Наши спикеры
			</Title>
			<Title
				w="100%"
				ta={{ xs: "left", sm: "center" }}
				order={1}
				fw="bold"
				py="50px"
				pl={{ xs: "sm", sm: "0" }}
				hiddenFrom="md"
			>
				Готовятся к общению
			</Title>
			<Flex
				wrap="wrap"
				gap="sm"
				justify="center"
				align="center"
				pb="50px"
				px="calc(20% - 25px)"
			>
				{profile}
				{profile}
				{profile}
				{profile}
				{profile}
				{profile}
			</Flex>
		</>
	);
}
