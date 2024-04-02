import { BaseWidget } from "./BaseWidget.js";

class PrimitiveWidget extends BaseWidget {
	#divElement;
	#job;

	constructor(id) {
		super(id);
		this.#divElement = document.createElement("div");

		this.#updateContent();

		this.#job = setInterval(() => {
			this.#updateContent();
		}, 1000);
	}

	fillContainer(container) {
		container.appendChild(this.#divElement);
	}

	onRemove() {
		clearInterval(this.#job);
	}

	#updateContent() {
		const currentTime = new Date();
		const timeString = new Intl.DateTimeFormat("en-US", {
			hour: "2-digit",
			minute: "2-digit",
			second: "2-digit",
			hour12: false,
		}).format(currentTime);

		const content = `Time is: ${timeString}`;
		this.#divElement.textContent = content;
	}
}

export { PrimitiveWidget };
