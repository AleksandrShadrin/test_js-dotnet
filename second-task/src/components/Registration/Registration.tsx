import { Button, Input, Modal, Stack, Text, Title } from "@mantine/core";
import { useDisclosure } from "@mantine/hooks";

export default function Registration() {
	const [opened, { open, close }] = useDisclosure(false);

	return (
		<>
			<Button onClick={open} bg="transparent" p={0}>
				<Title order={1} ta={{ xs: "left", sm: "center" }} c="black">
					Регистрация
				</Title>
			</Button>
			<Modal opened={opened} onClose={close} title="Регистрация">
				<Stack gap="sm">
					<Input placeholder="ФИО" />
					<Input placeholder="Место работы" />
					<Input placeholder="E-mail" />
					<Button bg="green" onClick={close}>
						<Text c="white">Accept</Text>
					</Button>
				</Stack>
			</Modal>
		</>
	);
}
