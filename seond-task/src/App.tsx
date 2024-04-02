import Header from "./components/Header/Header";
import { Container, Flex, MantineProvider, createTheme } from "@mantine/core";

import "@mantine/core/styles.css";
import Welcome from "./components/Welcome/Welcome";
import Speakers from "./components/Speakers/Speakers";
import Footer from "./components/Footer/Footer";

const theme = createTheme({
	breakpoints: {
		xs: "0px",
		sm: "321px",
		md: "769px",
		lg: "1920px",
	},
});

function App() {
	return (
		<MantineProvider theme={theme}>
			<Flex
				direction="column"
				mih="100vh"
				miw="var(--mantine-breakpoint-sm)"
				justify="space-between"
			>
				<Header />
				<Welcome />
				<Speakers />
				<Footer />
			</Flex>
		</MantineProvider>
	);
}

export default App;
