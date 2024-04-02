import { WeatherWidget } from "./Widgets/WeatherWidget";
import { PrimitiveWidget } from "./Widgets/PrimitiveWidget";
import { WidgetManager } from "./Widgets/WidgetManager";

const widgets = {
	WeatherWidget: "weather widget",
	PrimitiveWidget: "primitive widget",
};

document.addEventListener("DOMContentLoaded", () => {
	const widgetManager = new WidgetManager();

	const dateWidget1 = new WeatherWidget(1);
	const dateWidget2 = new WeatherWidget(2);
	const dateWidget3 = new WeatherWidget(3);
	const primitiveWidget = new PrimitiveWidget(4);

	widgetManager.addWidget(dateWidget1);
	widgetManager.moveWidgets("widgets-container1");

	widgetManager.addWidget(dateWidget2);
	widgetManager.addWidget(dateWidget3);
	widgetManager.moveWidgets("widgets-container2");

	widgetManager.addWidget(primitiveWidget);
	widgetManager.moveWidgets("widgets-container3");

	registerWidgetAdders(widgetManager);
});

function registerWidgetAdders(widgetManager) {
	const adders = document.querySelectorAll("select[name=add-widget]");
	adders.forEach((adder) => {
		adder.innerHTML = `
			<option value="" selected disabled hidden>
				Add widget
			</option>
		`;
		adder.innerHTML += Object.keys(widgets).map(
			(wk) => `<option value=${wk}>${widgets[wk]}</option>`
		);
		adder.onchange = (e) => {
			const value = e.target.value;
			const widget = createWidget(value);
			const parent = e.target.parentNode;

			if (widget) {
				widgetManager.addWidget(widget);
				widgetManager.moveWidgets(parent.id);
			}

			adder.selectedIndex = 0;
		};
	});
}

function createWidget(value) {
	if (value === "WeatherWidget") {
		const time = new Date().getTime();
		return new WeatherWidget(time);
	}

	if (value === "PrimitiveWidget") {
		const time = new Date().getTime();
		return new PrimitiveWidget(time);
	}

	return null;
}
