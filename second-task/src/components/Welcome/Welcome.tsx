import { Container, Flex, Table, Text } from "@mantine/core";

import classes from "./Welcome.module.css";
import Registration from "../Registration/Registration";

export default function Welcome() {
	return (
		<Flex className={classes.body} align="center" gap="lg" pl="sm">
			<Container className={classes["text-container"]} visibleFrom="sm" pl="sm">
				<Text ta={{ sm: "left", md: "center" }}>
					Дорогие друзья! <br></br>
					<br></br>Lorem ipsum dolor sit amet, consectetur adipiscing elit, sed
					do eiusmod tempor incididunt ut labore et dolore magna aliqua. Turpis
					nunc eget lorem dolor sed viverra ipsum nunc. Mattis enim ut tellus
					elementum sagittis vitae et leo duis. Odio ut enim blandit volutpat
					maecenas volutpat. Lectus sit amet est placerat in egestas erat
					imperdiet sed. Risus pretium quam vulputate dignissim suspendisse.
					Viverra tellus in hac habitasse platea dictumst vestibulum rhoncus.
					Lorem ipsum dolor sit amet consectetur adipiscing elit ut aliquam.
					Pretium lectus quam id leo in vitae turpis massa. Tristique risus nec
					feugiat in fermentum.
				</Text>
			</Container>
			<Container className={classes["text-container"]} p={{ xs: 0, sm: "sm" }}>
				<Registration />
				<Text py="md">
					Пожалуйста, проверьте правильность введенных данных:<br></br>
				</Text>
				<Table borderColor="transparent">
					<Table.Tbody>
						<Table.Tr>
							<Table.Th p={0} fw="normal">
								ФИО:
							</Table.Th>
							<Table.Th p={0} fw="normal">
								Иванов Иван Иванович
							</Table.Th>
						</Table.Tr>

						<Table.Tr>
							<Table.Th p={0} fw="normal">
								Место работы:
							</Table.Th>
							<Table.Th p={0} fw="normal">
								DIRECTUM
							</Table.Th>
						</Table.Tr>

						<Table.Tr>
							<Table.Th p={0} fw="normal">
								E-mail:
							</Table.Th>
							<Table.Th p={0} fw="normal">
								ivanov_ii@directum.ru
							</Table.Th>
						</Table.Tr>
					</Table.Tbody>
				</Table>
			</Container>
		</Flex>
	);
}
