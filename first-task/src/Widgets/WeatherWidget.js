import { BaseWidget } from "./BaseWidget.js";
import WeatherService from "../services/WeatherService.js";

import styles from "./WeatherWidget.styles.css";

class WeatherWidget extends BaseWidget {
	#weatherService;
	#select;

	constructor(id) {
		super(id);
		this.#weatherService = new WeatherService(
			"6d2e1430bb47f0915d8d4628b4278769"
		);
	}

	fillContainer(container) {
		container.classList.add(styles["weather-widget"]);
		const textField = document.createElement("div");
		textField.innerText = "Enter city";

		container.appendChild(textField);

		const select = document.createElement("select");

		select.innerHTML = `
            <option value="">Select a city</option>
            <option value="Moscow">Moscow</option>
            <option value="Saint Petersburg">Saint Petersburg</option>
            <option value="Novosibirsk">Novosibirsk</option>
            <option value="Yekaterinburg">Yekaterinburg</option>
            <option value="Kazan">Kazan</option>
            <option value="Nizhny Novgorod">Nizhny Novgorod</option>
            <option value="Chelyabinsk">Chelyabinsk</option>
            <option value="Omsk">Omsk</option>
            <option value="Samara">Samara</option>
            <option value="Rostov-on-Don">Rostov-on-Don</option>
        `;
		select.onchange = this.#onInput(textField);

		this.#select = select;
		container.appendChild(select);
	}

	/**
	 * fetch temperature of city
	 * @param {string} resultFieldElement one of listed cities
	 * @returns
	 */
	#onInput(resultFieldElement) {
		return (event) => {
			const city = event.target.value;
			this.#select.disabled = true;

			this.#weatherService.getCurrentTemperature(city).then((temperature) => {
				if (temperature) {
					this.#select.disabled = false;
					resultFieldElement.innerText = `Current temperature in ${city}: ${temperature}°C`;
				} else {
					resultFieldElement.innerText = `Error in processing for ${city}`;
				}
			});
		};
	}
}

export { WeatherWidget };
