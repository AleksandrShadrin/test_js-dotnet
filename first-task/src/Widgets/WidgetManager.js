import IWidget from "./BaseWidget.js";

class WidgetManager {
	#widgets;

	constructor() {
		this.#widgets = [];
	}

	/**
	 * Add widget
	 * @param {IWidget} widget
	 */
	addWidget(widget) {
		if (typeof widget.render === "function") {
			this.#widgets.push(widget);
		} else {
			console.error(
				"This widget does not implement the required render method."
			);
		}
	}

	/**
	 * Move added widgets in choosen container
	 * @param {string} containerId Id of container in which widgets will be added
	 */
	moveWidgets(containerId) {
		const container = document.getElementById(containerId);
		if (!container) {
			console.error("Container not found");
			return;
		}

		this.#widgets.forEach((widget) => {
			this.#appendToElement(container, widget.render());
		});

		this.#widgets = [];
	}

	/**
	 * append string or HTMLElement
	 * @param {string} parentElement
	 * @param {string | HTMLElement} content
	 */
	#appendToElement(parentElement, content) {
		if (typeof content === "string") {
			parentElement.innerHTML += content;
		} else {
			parentElement.appendChild(content);
		}
	}
}

export { WidgetManager };
