window.darkSkyStays = {
    showDialog(dialog) {
        if (dialog && !dialog.open) {
            dialog.showModal();
        }
    },
    closeDialog(dialog) {
        dialog?.close();
    },
    scrollTo(element) {
        element?.scrollIntoView({
            behavior: window.matchMedia("(prefers-reduced-motion: reduce)").matches ? "instant" : "smooth",
            block: "start"
        });
    }
};
