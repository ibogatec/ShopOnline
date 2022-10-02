function makeUpdateQtyButtonVisible(cartItemId, visible) {

    const updateQtyButton = document.getElementById(`updateQty-${cartItemId}`);

    updateQtyButton.style.display = visible ? "inline-block" : "none";
}
