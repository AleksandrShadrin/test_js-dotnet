import styles from "./BaseWidget.styles.css";

/**
 * Widgets base class
 */
class BaseWidget {
	#container;
	#id;

	constructor(id) {
		this.#id = id;

		const container = document.createElement("div");

		container.id = this.#id;
		container.classList.add(styles["widget"]);
		container.draggable = true;
		container.ondragstart = drag;

		const buttonHolder = document.createElement("div");
		buttonHolder.classList.add(styles["button-holder"]);

		const button = document.createElement("button");
		button.classList.add(styles["button"]);
		button.textContent = "❌";

		button.onclick = () => {
			container.remove();
			this.onRemove();
		};

		buttonHolder.appendChild(button);

		container.appendChild(buttonHolder);

		this.#container = container;
	}

	/**
	 *  Returns container
	 * @returns {string | HTMLElement}
	 */
	render() {
		this.fillContainer(this.#container);
		return this.#container;
	}

	/**
	 * User's implementation of container content
	 * @param {HTMLElement} container
	 */
	fillContainer(container) {}

	/**
	 * Executed on widget remove
	 */
	onRemove() {}
}

export { BaseWidget };
