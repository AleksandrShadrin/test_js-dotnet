class WeatherService {
	#apiKey;
	#apiUrl;

	constructor(apiKey) {
		this.#apiKey = apiKey;
		this.#apiUrl = "https://api.openweathermap.org/data/2.5/weather";
	}

	async getCurrentTemperature(city) {
		try {
			const response = await fetch(
				`${this.#apiUrl}?q=${city}&appid=${this.#apiKey}`
			);
			const data = await response.json();
			const temperatureKelvin = data.main.temp;
			const temperatureCelsius = temperatureKelvin - 273.15;
			return temperatureCelsius.toFixed(1);
		} catch (error) {
			console.error("Error fetching data:", error);
			return null;
		}
	}
}

export default WeatherService;
